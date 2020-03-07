using FluentSpecification.Abstractions.Validation;
using SMS.Core.Result;

namespace SMS.Core.Result
{
  public static class Results
  {

      
        public static Result<T> WithOk<T>(T data)
        {
            return new Result<T>(data)
            {
                IsOk = true
            };
        }

       

        
        public static ResultSpec<T> WithOkSpec<T>(T data)
        {
            return new ResultSpec<T>(data)
            {
                IsOk = true
            };
        }

       

        public static Result<T> WithFail<T>(T data)
        {
            return new Result<T>(data)
            {
                IsOk = false
            };
        }


        public static ResultSpec<T> WithFailSpec<T>(T data)
        {
            return new ResultSpec<T>(data)
            {
                IsOk = true
            };
        }



        public static ResultSpec<T> AddMessage<T>(this ResultSpec<T> result, string message)
        {
            result.Message = message;

            return result;
        }

        public static Result<T> AddMessage<T>(this Result<T> result, string message)
        {
            result.Message = message;

            return result;
        }

        public static ResultSpec<T> AddSpec<T>(this ResultSpec<T> result, SpecificationResult specResult)
        {
            result.SpecResult = specResult;

            return result;
        }





    }
}
