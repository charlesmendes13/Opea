using MediatR;

namespace Opea.Application.Commands
{
    public class DeleteClientCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public DeleteClientCommand(int id)
        {
            Id = id;
        }
    }
}
