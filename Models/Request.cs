using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair3v.Models
{
    public class Request
    {
        // Номер заявки
        [Key]
        public string RequestNumber { get; set; }

        // Описание заявки
        public string Description { get; set; }

        // Тип заявки
        public string Type { get; set; }

        // Описание проблемы
        public string ProblemDescription { get; set; }

        // Дата создания заявки
        public DateOnly CreationDate { get; set; }

        // Статус заявки
        public RequestStatus Status { get; set; }

        // Ответственный мастер
        public User ResponsibleMaster { get; set; }


    }

    public enum RequestStatus
    {
        InProcessing,   // В обработке
        InWork,         // В работе
        Completed       // Завершена
    }
}