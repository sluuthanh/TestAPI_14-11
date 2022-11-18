namespace Api.Models.ViewDTO
{
    public class ResponseMessage
    {
        public ResponseMessage() { }
        public ResponseMessage(object data = null)
        {
            Data = data;

        }
        public ResponseMessage(int status = 0, string message = "")
        {
            Status = status;
            Message = message;

        }
        public ResponseMessage(int status = 0, string message = "", object data = null)
        {
            Status = status;
            Message = message;
            Data = data;

        }
        public ResponseMessage(bool isSuccess, int status = 0, string message = "", object data = null)
        {
            IsSuccess = isSuccess;
            Status = status;
            Message = message;
            Data = data;

        }
        public ResponseMessage(bool isSuccess, int status = 0, string message = "", object data = null, string name = null)
        {
            IsSuccess = isSuccess;
            Status = status;
            Message = message;
            Data = data;
            Name = name;

        }
        public bool IsSuccess { get; set; }
        public int Status { get; set; }

        public string Message { get; set; }
        public object Data { get; set; }
        public string Name { get; set; }
        public object List { get; set; }
    }
}
