using System;
using System.Collections.Generic;

namespace Model
{
    public class RastrData: ICloneable
    {
        /// <summary>
        /// Спискок, хранящий номера узлов из файла rst 
        /// </summary>
        public List<int> NumbersOfNodesFromRastr { get; }

        /// <summary>
        /// Спискок, хранящий номера сечений из файла sch
        /// </summary>
        public List<int> NumbersOfSectionsFromRastr { get; }

        /// <summary>
        /// Генераторы исследуемой станции.
        /// С их помощью будет осуществляться регулирование 
        /// напряжения-влияющего фактора
        /// Список формируется в форме TrajectorySettingsForm
        /// </summary>
        public List<int> ResearchingPlantGenerators { get; }


        public RastrData(List<int> numbersOfNodesFromRastr,
            List<int> numbersOfSectionsFromRastr,
            List<int> researchingPlantGenerators)
        {
            NumbersOfNodesFromRastr = numbersOfNodesFromRastr;
            NumbersOfSectionsFromRastr = numbersOfSectionsFromRastr;
            ResearchingPlantGenerators = researchingPlantGenerators;
        }

        public object Clone()
        {
            return new RastrData(NumbersOfNodesFromRastr,
                NumbersOfSectionsFromRastr,
                ResearchingPlantGenerators);
        }
    }
}
