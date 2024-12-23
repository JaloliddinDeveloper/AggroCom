// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------
using AggroCom.Brokers.Storages;
using AggroCom.Models.Foundations.Contacts;
using AggroCom.Services.Foundations.Contacts;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AggroCom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController:RESTFulController
    {
        private readonly IStorageBroker storageBroker;
        private readonly IContactService contactService;

        public ContactController(
            IStorageBroker storageBroker, 
            IContactService contactService)
        {
            this.storageBroker = storageBroker;
            this.contactService = contactService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Contact>> PostContactAsync(Contact contact)
        {
            try
            {
                Contact addedContact = await this.storageBroker.InsertContactAsync(contact);

                return Created(addedContact);
            }
            catch(Exception  ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        public async ValueTask<ActionResult<IQueryable<Contact>>> GetAllContactsAsync()
        {
            try
            {
                IQueryable<Contact> contacts = await this.storageBroker.SelectAllContactsAsync();

                return Ok(contacts);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async ValueTask<ActionResult<Contact>> DeleteContactByIdAsync(int Id)
        {
            try
            {
                return await this.contactService.RemoveContactAsync(Id);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
