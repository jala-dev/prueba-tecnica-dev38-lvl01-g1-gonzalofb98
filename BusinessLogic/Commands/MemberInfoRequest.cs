using Data;
using Data.Entities;
using Presentation;
using Presentation.View;

namespace BusinessLogic.Commands
{
    class MemberInfoRequest
    {
            MemberRepository _repository = new MemberRepository();
        public void Execute()
        {
            MemberInfoView view = new MemberInfoView();
            InputData data = view.RequestData();
            Member entity = new Member();
            entity.ID = int.Parse(data.fields["CodigoSocio"]);

            Member member = _repository.GetMember(entity.ID);

            if (member is null)
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"El código {entity.ID} no existe.");
            }
            else
            {
                view.ShowResult(member.FirstName + " " + member.SecondName);
            }

        }
    }
}
