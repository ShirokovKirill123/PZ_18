using Data_BusinessLogic.DB.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data_BusinessLogic.DB
{
    public class Request : IRequest, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; private set; }

        private DateTime startDate;
        [Required]
        [JsonPropertyName("startDate")]
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private string problemDescription;
        [Required]
        [MaxLength(2048)]
        [JsonPropertyName("problemDescription")]
        public string ProblemDescription
        {
            get => problemDescription;
            set
            {
                problemDescription = value;
                OnPropertyChanged(nameof(ProblemDescription));
            }
        }

        private DateTime? completionDate;
        [JsonPropertyName("completionDate")]
        public DateTime? CompletionDate
        {
            get => completionDate;
            set
            {
                completionDate = value;
                OnPropertyChanged(nameof(CompletionDate));
            }
        }

        private int homeTechTypeId;
        [Required]
        [JsonPropertyName("homeTechTypeId")]
        public int HomeTechTypeId
        {
            get => homeTechTypeId;
            set
            {
                homeTechTypeId = value;
                OnPropertyChanged(nameof(HomeTechTypeId));
            }
        }

        private int? homeTechModelId;
        [JsonPropertyName("homeTechModelId")]
        public int? HomeTechModelId
        {
            get => homeTechModelId;
            set
            {
                homeTechModelId = value;
                OnPropertyChanged(nameof(HomeTechModelId));
            }
        }

        private int? repairPartsId;
        [JsonPropertyName("repairPartsId")]
        public int? RepairPartsId
        {
            get => repairPartsId;
            set
            {
                repairPartsId = value;
                OnPropertyChanged(nameof(RepairPartsId));
            }
        }

        private int clientId;
        [Required]
        [JsonPropertyName("clientId")]
        public int ClientId
        {
            get => clientId;
            set
            {
                clientId = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }

        private int? masterId;
        [JsonPropertyName("masterId")]
        public int? MasterId
        {
            get => masterId;
            set
            {
                masterId = value;
                OnPropertyChanged(nameof(MasterId));
            }
        }

        private int statusId;
        [Required]
        [JsonPropertyName("statusId")]
        public int StatusId
        {
            get => statusId;
            set
            {
                statusId = value;
                OnPropertyChanged(nameof(StatusId));
            }
        }

        [JsonIgnore]
        public bool IsCompleted => CompletionDate.HasValue;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
