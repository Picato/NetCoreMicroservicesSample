﻿using Events.Users;
using Infrastructure.EventStores.Aggregates;
using System;

namespace UsersService
{
    public class UserAggregate : Aggregate
    {
        public Guid UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }


        protected UserAggregate()
        {}

        private UserAggregate(string firstName, string lastName, string email)
        {
            var @event = new UserCreatedEvent
            {
                UserId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            Enqueue(@event);
            Apply(@event);
        }

        public static UserAggregate CreateUser(string firstName, string lastName, string email)
        {
            return new UserAggregate(firstName, lastName, email);
        }



        public void Apply(UserCreatedEvent @event)
        {
            UserId = @event.UserId;
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            Email = @event.Email;
        }
    }
}