using System;

namespace WoW.Core.Attempt
{
    public struct Attempt<T>
    {
        private readonly bool _success;
        private readonly T _result;
        private readonly Exception _exception;

        public bool Success
        {
            get { return _success; }
        }

        public Exception Exception
        {
            get { return _exception; }
        }

        public T Result
        {
            get { return _result; }
        }

        // private - use Succeed() or Fail() methods to create attempts
        private Attempt(bool success, T result, Exception exception)
        {
            _success = success;
            _result = result;
            _exception = exception;
        }

        public static Attempt<T> Succeed()
        {
            return new Attempt<T>(true, default(T), null);
        }

        public static Attempt<T> Succeed(T result)
        {
            return new Attempt<T>(true, result, null);
        }

        public static Attempt<T> Fail()
        {
            return new Attempt<T>(false, default(T), null);
        }

        public static Attempt<T> Fail(Exception exception)
        {
            return new Attempt<T>(false, default(T), exception);
        }

        public static Attempt<T> Fail(T result)
        {
            return new Attempt<T>(false, result, null);
        }
        public static Attempt<T> Fail(T result, Exception exception)
        {
            return new Attempt<T>(false, result, exception);
        }
        public static Attempt<T> SucceedIf(bool condition)
        {
            return condition ? new Attempt<T>(true, default(T), null) : new Attempt<T>(false, default(T), null);
        }

        public static Attempt<T> SucceedIf(bool condition, T result)
        {
            return new Attempt<T>(condition, result, null);
        }

        public static implicit operator bool(Attempt<T> a)
        {
            return a.Success;
        }
    }
}