/*
 * Copyright (C) 2024-2025 Caleb H. (K4PHP) caleb.k4php@gmail.com
 *
 * This file is part of the WhackerLinkServer project.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Affero General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Affero General Public License for more details.
 *
 * You should have received a copy of the GNU Affero General Public License
 * along with this program. If not, see <https://www.gnu.org/licenses/>.
 *
 * DO NOT ALTER OR REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 */

using WhackerLinkLib.Network;

namespace WhackerLinkLib.Managers
{
    /// <summary>
    /// WhackerLink peer/client websocket manager for having multiple systems
    /// </summary>
    public class WebSocketManager
    {
        private readonly Dictionary<string, Peer> _webSocketHandlers;

        /// <summary>
        /// Creates an instance of <see cref="WebSocketManager"/>
        /// </summary>
        public WebSocketManager()
        {
            _webSocketHandlers = new Dictionary<string, Peer>();
        }

        /// <summary>
        /// Create a new <see cref="Peer"/> for a new system
        /// </summary>
        /// <param name="systemId"></param>
        public void AddWebSocketHandler(string systemId)
        {
            if (!_webSocketHandlers.ContainsKey(systemId))
            {
                _webSocketHandlers[systemId] = new Peer();
            }
        }

        /// <summary>
        /// Return a <see cref="Peer"/> by looking up a systemid
        /// </summary>
        /// <param name="systemId"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Peer GetWebSocketHandler(string systemId)
        {
            if (_webSocketHandlers.TryGetValue(systemId, out var handler))
            {
                return handler;
            }
            throw new KeyNotFoundException($"WebSocketHandler for system '{systemId}' not found.");
        }

        /// <summary>
        /// Delete a <see cref="Peer"/> by system id
        /// </summary>
        /// <param name="systemId"></param>
        public void RemoveWebSocketHandler(string systemId)
        {
            if (_webSocketHandlers.TryGetValue(systemId, out var handler))
            {
                handler.Disconnect();
                _webSocketHandlers.Remove(systemId);
            }
        }

        /// <summary>
        /// Check if the manager has a handler
        /// </summary>
        /// <param name="systemId"></param>
        /// <returns></returns>
        public bool HasWebSocketHandler(string systemId)
        {
            return _webSocketHandlers.ContainsKey(systemId);
        }

        /// <summary>
        /// Cleanup
        /// </summary>
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

