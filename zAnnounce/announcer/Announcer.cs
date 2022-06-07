using SDG.Unturned;
using System;
using System.Collections;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace zAnnounce.announcer
{
    class Announcer : MonoBehaviour
    {
        public int lastIndex = 0;
        public int delay = zAnnouncePlugin.config.Instance.delay;
        private float _nextAnnounceTime;

        void Update()
        {
            if(timeToAnnounce())
            {
                Announce();
            }
        }

        private void Announce()
        {
            _nextAnnounceTime = Time.time + delay;

            if (lastIndex > (zAnnouncePlugin.config.Instance.Messages.Length - 1)) lastIndex = 0;

            Message message = zAnnouncePlugin.config.Instance.Messages[lastIndex];
            lastIndex++;

            try
            {
                Logger.Log("Ran announcement: " + lastIndex);
                ChatManager.serverSendMessage(
                        message.Text,
                        _colorFromString(message.Color),
                        null,
                        null,
                        EChatMode.SAY,
                        message.Icon ?? "",
                        message.Rich || false
                    );
            }
            catch (Exception err)
            {
                Logger.LogError("Failed to announce message: " + err);
            }
        }

        private bool timeToAnnounce()
        {
            return Time.time >= _nextAnnounceTime;
        }

        public static UnityEngine.Color _colorFromString(string color)
        {
            UnityEngine.Color returnCoor = UnityEngine.Color.green;

            switch (color.ToString().ToLower())
            {
                case "green":
                    returnCoor = UnityEngine.Color.green;
                    break;
                case "red":
                    returnCoor = UnityEngine.Color.red;
                    break;
                case "yellow":
                    returnCoor = UnityEngine.Color.yellow;
                    break;
                case "gray":
                    returnCoor = UnityEngine.Color.gray;
                    break;
                case "grey":
                    returnCoor = UnityEngine.Color.grey;
                    break;
                case "blue":
                    returnCoor = UnityEngine.Color.blue;
                    break;
                case "cyan":
                    returnCoor = UnityEngine.Color.cyan;
                    break;
                case "black":
                    returnCoor = UnityEngine.Color.black;
                    break;
                case "clear":
                    returnCoor = UnityEngine.Color.clear;
                    break;
                default:
                    returnCoor = UnityEngine.Color.green;
                    break;
            }

            return returnCoor;
        }
    }
}
