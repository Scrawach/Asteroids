using UnityEngine;

namespace Extensions
{
    public static class AsyncOperationExtensions
    {
        public static bool NotDoneYet(this AsyncOperation self) =>
            self.isDone == false;
    }
}