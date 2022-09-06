using BusinessLogic.Core;
using Data;
using Data.Entities;
using Presentation;
using Presentation.View;

namespace BusinessLogic.Commands
{
    public class SaveConsumption: IWaterCommand
    {
        MemberRepository _repository = new MemberRepository();
        public void Execute()
        {
            InputData data = new SaveConsumptionView().RequestData();
            Consumption entity = new Consumption();
            entity.MemberID = int.Parse(data.fields["CodigoSocio"]);
            entity.Value = int.Parse(data.fields["Consumo"]);

            if (_repository.GetMember(entity.MemberID) is null)
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"El código de socio no existe.");
            }
            else if (entity.Value < 0)
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"El consumo no puede ser menor a 0.");
            }
            else
            {
                new ConsumptionRepository().Save(entity);
            }
        }
    }
}
