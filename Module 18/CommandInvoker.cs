namespace Module18
{
    class CommandInvoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public async Task RunAsync()
        {
            await Task.Run(() => _command.ExecuteAsync());
        }
    }

}
