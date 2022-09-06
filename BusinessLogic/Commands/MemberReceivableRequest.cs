using BusinessLogic.Core;
using Data;
using Data.Entities;
using Presentation;
using Presentation.View;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Commands
{
    public class MemberReceivableRequest: IWaterCommand
    {
        double _waterPrice = 8.5;
        MemberRepository _repository = new MemberRepository();
        public void Execute()
        {
            UserReceivableView view = new UserReceivableView();
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
                List<Consumption> memberConsumptions = new ConsumptionRepository().GetConsumptionByMember(entity);

                double total = CalculateTotalReceivable(memberConsumptions);
                int totalCube = CalculateTotalOfCubes(memberConsumptions);

                view.ShowResult(entity.ID, totalCube, total);            
            }
        }

        private int CalculateTotalOfCubes(List<Consumption> memberConsumptions)
        {
            int total = 0;
            foreach(var consumption in memberConsumptions)
            {
                total+= consumption.Value;
            }
            return total;
        }

        private double CalculateTotalReceivable(List<Consumption> memberConsumptions)
        {
            double total = 0;
            foreach(Consumption item in memberConsumptions)
            {
                total += item.Value * _waterPrice;
            }
            return total;
        }
    }
}
