using jim.hex.common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace jim.hex.common.Results
{
    /// <summary>
    /// Object that especifies the result an operation
    /// </summary>
    public class Result
    {
        private IEnumerable<string> _errors;

        /// <summary>
        /// The operation was completed with errors
        /// </summary>
        public bool IsFailed => _errors.HasContent();

        /// <summary>
        /// The operation was completed without errors
        /// </summary>
        public bool IsSuccessful => !IsFailed;

        public ReadOnlyCollection<String> Errors => _errors.ToList().AsReadOnly();

        public Result()
        {
            _errors = new List<string>();
        }

        /// <summary>
        /// Aggregate an error an asign the Result failed
        /// </summary>
        /// <param name="error"></param>
        /// <exception cref="ArgumentNullException">the error cannot be null or empty</exception>
        public void AddError(string error)
        {
            if(String.IsNullOrWhiteSpace(error))
            {
                throw new ArgumentNullException(nameof(error));
                
            }
            _errors.Append(error);
        }

        /// <summary>
        /// Aggreate an list of errors and turns failed the result
        /// </summary>
        /// <param name="errors"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddError(IEnumerable<string> errors)
        {
            if (errors.NotHasContent())
            {
                throw new ArgumentNullException(nameof(errors));
            }

            foreach (var error in errors)
            {
                AddError(error);
            }
        }

        /// <summary>
        /// return a Result correct of a operation
        /// </summary>
        /// <returns></returns>
        public static Result Ok()
        {
            return new Result();
        }

        /// <summary>
        /// Return a Result failed with the speficifed error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Result Fail(string error)
        {
           return Result.Fail(new List<string> { error });
        }

        /// <summary>
        /// Return a Result failed with the specifies errors
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static Result Fail(IEnumerable<string> errors)
        {
            var result = new Result();
            result.AddError(errors);
            return result;
        }

        /// <summary>
        /// return the Ok error with the value specified
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result<TValue> Ok<TValue>(TValue value)
        {
            return new Result<TValue>(value);
        }

        /// <summary>
        /// Return a Result failed with the speficifed error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static Result<TValue> Fail<TValue>(string error)
        {
            return Fail<TValue>(new List<string> { error });
        }

        /// <summary>
        /// Return a Result failed with the specifies errors
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static Result<TValue> Fail<TValue>(IEnumerable<string> errors)
        {
            var result = new Result<TValue>(default);
            result.AddError(errors);
            return result;
        }

    }

    public class Result<TValue> : Result
    {
        public readonly TValue _value;
        public TValue Value => Value;

        public Result(TValue value) : base()
        {
            _value = value;
        }

        public static implicit operator Result<TValue>(TValue value) =>  Result.Ok<TValue>(value);



    }



}
