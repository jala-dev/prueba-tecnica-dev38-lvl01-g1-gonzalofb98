using Data;
using Data.Entities;
using Presentation;
using Presentation.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Commands
{
    public class GenerateReport
    {
        MemberRepository _repository = new MemberRepository();
        ConsumptionRepository _consumptionRepository = new ConsumptionRepository();
        public void Execute()
        {
            ReportView view = new ReportView();
            InputData data = view.RequestData();
            Member entity = _repository.GetMember(int.Parse(data.fields["CodigoSocio"]));

            if (entity == null)
            {
                ErrorView errorView = new ErrorView();
                errorView.ShowError($"El código de socio no existe.");
            }
            else
            {
                foreach (var cons in _consumptionRepository.GetConsumptionByMember(entity))
                {
                    cons.Paid = true;
                }
                var name = entity.FirstName + " " + entity.SecondName;
                double total = 0;
                view.ShowResult(entity.ID,name, total);
            }
        }
        private double CalculateTotalReceivable(List<Consumption> memberConsumptions)
        {
            double total = 0;
            foreach (Consumption item in memberConsumptions)
            {
                if (!item.Paid) total += item.Value * _waterPrice;
            }
            return total;
        }
    }
}
