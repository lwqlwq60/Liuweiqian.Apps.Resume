namespace Liuweiqian.Threading.Tasks
{
    using System.Threading.Tasks;

    public class TimeoutTaskCompletionSource : TaskCompletionSource<bool>
    {
        int timeout;

        public TimeoutTaskCompletionSource(int timeout)
        {
            this.timeout = timeout;
        }

        public void Complete()
        {
            if (this.Task.Status == TaskStatus.WaitingForActivation)
                this.SetResult(true);
        }

        public void Cancel()
        {
            if (this.Task.Status == TaskStatus.WaitingForActivation)
                this.SetResult(false);
        }

        public Task<bool> TimeoutTask
        {
            get
            {
                System.Threading.Tasks.Task.Factory.StartNew(async () =>
                {
                    await TaskEx.Delay(timeout);
                    if (this.Task.Status == TaskStatus.WaitingForActivation)
                        this.SetResult(false);
                });
                return this.Task;
            }
        }
    }
}
