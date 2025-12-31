using MediatR;

namespace MyApp.Application.Events
    {
    public record ProductCreatedEvent : INotification;
    }
