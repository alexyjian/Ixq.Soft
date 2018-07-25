using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Ixq.Soft.Core.Threading
{
    public static class TaskHelper
    {
        private static readonly TaskFactory TaskFactory = new TaskFactory(CancellationToken.None,
            TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        /// <summary>
        ///     将异步方法转换为同步方法执行。
        /// </summary>
        /// <typeparam name="TResult">表示异步方法返回结果的类型。</typeparam>
        /// <param name="func">异步执行的委托。</param>
        /// <returns>返回 <typeparamref name="TResult" />。</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;
            return TaskFactory.StartNew(() =>
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        ///     将异步方法转换为同步方法执行。
        /// </summary>
        /// <param name="func">异步执行的委托。</param>
        public static void RunSync(Func<Task> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;
            TaskFactory.StartNew(() =>
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureUi;
                return func();
            }).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        ///     将同步方法转换为异步操作。
        /// </summary>
        /// <param name="func">同步方法的委托。</param>
        /// <returns></returns>
        public static Task Run(Action func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;
            return TaskFactory.StartNew(() =>
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureUi;

                func();
            });
        }

        /// <summary>
        ///     将同步方法转换为异步操作。
        /// </summary>
        /// <param name="func">同步方法的委托。</param>
        /// <returns></returns>
        public static Task<TResult> Run<TResult>(Func<TResult> func)
        {
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;
            return TaskFactory.StartNew(() =>
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureUi;

                return func();
            });
        }
    }
}