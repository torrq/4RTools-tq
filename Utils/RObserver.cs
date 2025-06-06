﻿using System;
using System.Collections.Generic;

namespace _4RTools.Utils
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(Message message);
    }

    public enum MessageCode { 
        PROCESS_CHANGED,
        PROFILE_CHANGED,
        PROFILE_INPUT_CHANGE,
        TURN_ON,
        TURN_OFF,
        SHUTDOWN_APPLICATION,
        CLICK_ICON_TRAY,
        SERVER_LIST_CHANGED,
        ADDED_NEW_AUTOBUFF_SKILL,
        CHANGED_AUTOSWITCH_SKILL,
        ADDED_NEW_AUTOSWITCH_PETS,
    }

    public class Message
    {
        public MessageCode Code { get; }
        public object Data { get; set; }
        public Message() { }

        public Message(MessageCode code, object data)
        {
            this.Code = code;
            this.Data = data;
        }
    }

    public class Subject : ISubject
    {
        public Message Message { get; set; } = new Message();
        private readonly List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            DebugLogger.Info("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            DebugLogger.Info("Subject: Detached an observer.");
        }

        public void Notify(Message message)
        {
            DebugLogger.Info("Subject: Notifying observers...");
            this.Message = message;
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
