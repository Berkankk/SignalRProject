using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = createMessageDto.MessageSendDate,
                NameSurname = createMessageDto.NameSurname,
                PhoneNumber = createMessageDto.PhoneNumber,
                Status = false,
                Subject = createMessageDto.Subject
            };
            _messageService.TAdd(message);
            return Ok("Mesajınız başarılı bir şekilde oluşturuldu");

        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                MessageID = updateMessageDto.MessageID,
                NameSurname = updateMessageDto.NameSurname,
                PhoneNumber = updateMessageDto.PhoneNumber,
                Status = false,
                Subject = updateMessageDto.Subject
            };
            _messageService.TUpdate(message);
            return Ok("Mesajınız başarıyla güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Mesajınız başarıyla silindi");

        }

    }
}
