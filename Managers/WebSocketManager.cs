/*
* WhackerLink - WhackerLinkConsoleV2
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

using WhackerLinkLib.Handlers;

namespace WhackerLinkLib.Managers
{
    public class WebSocketManager
    {
        private readonly Dictionary<string, WebSocketHandler> _webSocketHandlers;

        public WebSocketManager()
        {
            _webSocketHandlers = new Dictionary<string, WebSocketHandler>();
        }

        public void AddWebSocketHandler(string systemId)
        {
            if (!_webSocketHandlers.ContainsKey(systemId))
            {
                _webSocketHandlers[systemId] = new WebSocketHandler();
            }
        }

        public WebSocketHandler GetWebSocketHandler(string systemId)
        {
            if (_webSocketHandlers.TryGetValue(systemId, out var handler))
            {
                return handler;
            }
            throw new KeyNotFoundException($"WebSocketHandler for system '{systemId}' not found.");
        }

        public void RemoveWebSocketHandler(string systemId)
        {
            if (_webSocketHandlers.TryGetValue(systemId, out var handler))
            {
                handler.Disconnect();
                _webSocketHandlers.Remove(systemId);
            }
        }

        public bool HasWebSocketHandler(string systemId)
        {
            return _webSocketHandlers.ContainsKey(systemId);
        }

        public void ClearAllWebSocketHandlers()
        {
            foreach (var handler in _webSocketHandlers.Values)
            {
                handler.Disconnect();
            }
            _webSocketHandlers.Clear();
        }
    }
}
