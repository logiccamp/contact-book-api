using ContactAPI.Data;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly ContactAPIDBContext dbContext;

        public ContactsController(ContactAPIDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(dbContext.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact();
            contact.Email = addContactRequest.Email;
            contact.Fullname = addContactRequest.Fullname;
            contact.Phone = addContactRequest.Phone;
            contact.Address = addContactRequest.Address;
            contact.id = Guid.NewGuid();

            await dbContext.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null) return NotFound();

            contact.Fullname = updateContactRequest.Fullname;
            contact.Email = updateContactRequest.Email;
            contact.Address = updateContactRequest.Address;
            contact.Phone = updateContactRequest.Phone;

            await dbContext.SaveChangesAsync();
            return Ok("success");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null) return NotFound();

            dbContext.Remove(contact);
            await dbContext.SaveChangesAsync();
            return Ok("Contact deleted");
        }
    }
}
