using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.UseCases
{
    public class AddUserCommand: IRequest<Guid>
    {
        public Due? dueRequst { get; set; }
    }

    public class AddDueUseCase : IRequestHandler<AddDueCommand, Guid>
    {
        private readonly IDueRepository _dueRepository;

        public AddDueUseCase(IDueRepository dueRepository)
        {
            _dueRepository = dueRepository;
        }

        public async Task<Guid> Handle(AddDueCommand request, CancellationToken cancellationToken)
        {
            if (request.dueRequst == null)
            {
                return Guid.Empty;
            }

            request.dueRequst.Id = Guid.NewGuid();
            var data = await _dueRepository.AddTaskAsync(request.dueRequst);

            return request.dueRequst.Id;
        }
    }
}
