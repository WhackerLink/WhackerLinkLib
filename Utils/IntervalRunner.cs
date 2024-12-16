/*
* WhackerLink - WhackerLinkLib
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* 
* Copyright (C) 2024 Caleb, K4PHP
* 
*/

namespace WhackerLinkLib.Utils
{
    public class IntervalRunner
    {
        private CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// Starts a task that runs at the specified interval in its own thread
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="interval">The interval in milliseconds.</param>
        public void Start(Action action, int interval)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (interval <= 0)
                throw new ArgumentOutOfRangeException(nameof(interval), "Interval must be greater than zero");

            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        action();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error in scheduled task: {ex.Message}");
                    }

                    try
                    {
                        Task.Delay(interval, token).Wait(token);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
            }, token);
        }

        /// <summary>
        /// Stops the interval
        /// </summary>
        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}
