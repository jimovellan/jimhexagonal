using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using jim.hex.common.Results;

namespace jim.hex.common.Extensions
{
    public static class ResultExtension
    {
        public static async Task<Result<TOut>> Then<TIn,TOut>(this Task<Result<TIn>> task, Func<TIn,Task<Result<TOut>>> nextMethod)
        {
            try
            {
                var result = await task;

                if (result.IsFailed)
                {
                    return Result.Fail<TOut>(result.Errors);
                }

                return await nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                 ExceptionDispatchInfo.Capture(ex).Throw();
                 throw;
            }
        }

        public static async Task<Result> Then<TIn>(this Task<Result<TIn>> task, Func<TIn, Task<Result>> nextMethod)
        {
            try
            {
                var result = await task;

                if (result.IsFailed)
                {
                    return Result.Fail(result.Errors);
                }

                return await nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result<Tout>> Then<Tout>(this Task<Result> task, Func<Task<Result<Tout>>> nextMethod)
        {
            try
            {
                var result = await task;

                if (result.IsFailed)
                {
                    return Result.Fail<Tout>(result.Errors);
                }

                return await nextMethod();
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result<TOut>> Then<TIn, TOut>(Result<TIn> result, Func<TIn, Task<Result<TOut>>> nextMethod)
        {
            try
            {
               

                if (result.IsFailed)
                {
                    return Result.Fail<TOut>(result.Errors);
                }

                return await nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result> Then<TIn>(this Result<TIn> result, Func<TIn, Task<Result>> nextMethod)
        {
            try
            {

                if (result.IsFailed)
                {
                    return Result.Fail(result.Errors);
                }

                return await nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result<Tout>> Then<Tout>(this Result result, Func<Task<Result<Tout>>> nextMethod)
        {
            try
            {
                

                if (result.IsFailed)
                {
                    return Result.Fail<Tout>(result.Errors);
                }

                return await nextMethod();
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }


        public static async Task<Result<TOut>> Then<TIn, TOut>(this Task<Result<TIn>> task, Func<TIn, Result<TOut>> nextMethod)
        {
            try
            {
                var result = await task;

                if (result.IsFailed)
                {
                    return Result.Fail<TOut>(result.Errors);
                }

                return  nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result> Then<TIn>(this Task<Result<TIn>> task, Func<TIn, Result> nextMethod)
        {
            try
            {
                var result = await task;

                if (result.IsFailed)
                {
                    return Result.Fail(result.Errors);
                }

                return  nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result<Tout>> Then<Tout>(this Task<Result> task, Func<Result<Tout>> nextMethod)
        {
            try
            {
                var result = await task;

                if (result.IsFailed)
                {
                    return Result.Fail<Tout>(result.Errors);
                }

                return  nextMethod();
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result<TOut>> Then<TIn, TOut>(Result<TIn> result, Func<TIn, Result<TOut>> nextMethod)
        {
            try
            {


                if (result.IsFailed)
                {
                    return Result.Fail<TOut>(result.Errors);
                }

                return  nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result> Then<TIn>(this Result<TIn> result, Func<TIn, Result> nextMethod)
        {
            try
            {

                if (result.IsFailed)
                {
                    return Result.Fail(result.Errors);
                }

                return  nextMethod(result.Value);
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }

        public static async Task<Result<Tout>> Then<Tout>(this Result result, Func<Result<Tout>> nextMethod)
        {
            try
            {


                if (result.IsFailed)
                {
                    return Result.Fail<Tout>(result.Errors);
                }

                return  nextMethod();
            }
            catch (Exception ex)
            {
                // Captura la excepción y se asegura que se procesa en el hilo principal
                ExceptionDispatchInfo.Capture(ex).Throw();
                throw;
            }
        }



    }
}
