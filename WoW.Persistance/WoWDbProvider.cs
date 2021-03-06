﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WoW.Core;
using WoW.Core.Enums;
using WoW.Core.Interfaces;
using WoW.Core.Models;

namespace WoW.Persistance
{
    public class WoWDbProvider : IWoWPersistanceProvider
    {
        private WoWDbContext _dbContext { get; set; }

        public WoWDbProvider()
        {
            _dbContext = new WoWDbContext();
        }

        public bool RaidNameAvailable(string name, string server)
        {
            //must use string compare, string.Equals errors
            return _dbContext.RaidGroup.None(r => string.Compare(r.RaidName, name, StringComparison.OrdinalIgnoreCase) == 0 &&
                string.Compare(r.Server, server, StringComparison.OrdinalIgnoreCase) == 0);
        }

        public int GetRaidByName(string name, string server)
        {
            //must use string compare, string.Equals errors
            var raid = _dbContext.RaidGroup.FirstOrDefault(r => string.Compare(r.RaidName, name, StringComparison.OrdinalIgnoreCase) == 0 &&
                string.Compare(r.Server, server, StringComparison.OrdinalIgnoreCase) == 0);
            return raid == null ? 0 : raid.RaidId;
        }

        public int CreateRaidGroup(string name, string server)
        {
            _dbContext.RaidGroup.Add(new RaidModel { RaidName = name, Server = server});
            _dbContext.SaveChanges();

            return GetRaidByName(name, server);
        }

        public bool AddRaider(PlayerModel raider)
        {
            try
            {
                if (_dbContext.Player.FirstOrDefault(r => r.Name == raider.Name && raider.Realm == r.Realm) != null)
                    return false;

                _dbContext.Player.Add(raider);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveRaider(int raiderId, int raidId)
        {
            try
            {
                var raider = _dbContext.Player.FirstOrDefault(p => p.PlayerId == raiderId && p.RaidId == raidId);

                if (raider == null)
                {
                    return false;
                }

                _dbContext.Player.Remove(raider);

                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public RaidModel GetRaiderDetails(int raidId)
        {
            try
            {
                var raid = _dbContext.RaidGroup.FirstOrDefault(r => r.RaidId == raidId);

                if (raid == null || raid.Raiders == null)
                    return raid;

                foreach (var raider in raid.Raiders.Where(raider => raider != null))
                {
                    raider.BuffsBrought = raider.GetBuffsBrought();
                    raider.UpdateValidationErrors();
                }

                return raid;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
