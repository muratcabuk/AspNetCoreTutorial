
using FluentSpecification.Abstractions.Validation;

namespace SMS.Core.Result
{

    public class Result<T>
    {
        public bool IsOk { get; set; }
        public string Message { get;set; }
        public T Data { get; set; } 

        public Result(T data)
        {
            this.Data = data;

        }


        //public Result<T> AddMessage(string message)
        //{
        //    this.Message = message;
        //    return this;
        //}

    }



    public class ResultSpec<T> 
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public SpecificationResult SpecResult { get; set; }


        public ResultSpec(T data)
        {
            this.Data = data;

        }

        //public ResultSpec<T> AddMessage(string message)
        //{
        //    this.Message = message;
        //    return this;
        //}

        //public ResultSpec<T> AddSpec(SpecificationResult specResult)
        //{
        //    this.SpecResult = specResult;
        //    return this;
        //}



    }



}
