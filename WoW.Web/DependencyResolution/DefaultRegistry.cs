// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using BattleNetApi;
using WarcraftLogs;
using WoW.Core.Interfaces;
using WoW.Persistance;
using WoW.Session;

namespace WoW.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            For<ICharacterImporter>().Use<BattleNetApiClient>().SelectConstructor(() => new BattleNetApiClient());
            For<IWoWPersistanceProvider>().Use<WoWDbProvider>();
            For<ILogApi>().Use<WarcraftLogsApi>();
            For<IRaidWrapper>().Use<RaidWrapper>();
            Scan(
                scan => {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
        }

        #endregion
    }
}