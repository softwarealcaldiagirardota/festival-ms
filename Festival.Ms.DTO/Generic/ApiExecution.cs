using static Festival.Ms.DTO.Generic.ResponseMessages;

namespace Festival.Ms.DTO.Generic
{
    public static class ApiExecution
    {
        public static async Task<ApiResponse<T>> RunAsync<T>(Task<T> method)
        {
            var result = new ApiResponse<T>();
            try
            {
                result.data = await method;
                result.SetState();
            }
            catch (Exception error)
            {
                result.LogError(error);
            }
            return result;
        }

        public async static Task<ApiResponse<Task>> RunAsync(Task method)
        {
            var result = new ApiResponse<Task>();
            try
            {
                await method;
                result.SetState(Messages.OK);
            }
            catch (Exception error)
            {
                result.LogError(error);
            }
            return result;
        }
    }
}

