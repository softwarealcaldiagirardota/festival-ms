using static Festival.Ms.DTO.Generic.ResponseMessages;
namespace Festival.Ms.DTO.Generic
{
    public class ApiResponse<T>
    {
        public bool state { get; set; }
        public string? responseType { get; set; }
        public string? message { get; set; }
        public string? additionalMessage { get; set; }
        public T? data { get; set; }

        public ApiResponse()
        {
            state = false;
            responseType = Messages.EMPTY.ToString();
        }

        public void SetState()
        {
            if (data != null)
            {
                state = true;
                responseType = Messages.OK.ToString();
                if (!Convert.ToBoolean(data))
                {
                    message = "Error al guardar, codigo ya usado o erroneo";
                    responseType = Messages.ERROR.ToString();
                    state = false;
                }
            }
        }

        public void SetState(Messages responseTypeEnum)
        {
            if (responseTypeEnum == Messages.OK)
                state = true;
            else
                state = false;
            responseType = responseTypeEnum.ToString();
        }

        public void LogError(Exception error)
        {
            message = error?.Message;
            additionalMessage = $"{error?.InnerException?.Message} {error?.StackTrace}";
            SetState(Messages.ERROR);
        }

        public void LogError(string error)
        {
            message = error;
            SetState(Messages.ERROR);
        }

    }
}

