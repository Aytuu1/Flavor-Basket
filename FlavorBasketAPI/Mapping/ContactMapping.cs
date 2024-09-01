using AutoMapper;
using FlavorB.DtoLayer.ContactDto;
using FlavorB.EntityLayer.Entities;

namespace FlavorBasketAPI.Mapping
{
  public class ContactMapping:Profile
  {
        public ContactMapping()
        {
            CreateMap<Contact,ResultContactDto>().ReverseMap();
            CreateMap<Contact,CreateContactDto>().ReverseMap();
            CreateMap<Contact,UpdateContactDto>().ReverseMap();
            CreateMap<Contact,GetContactDto>().ReverseMap();

        }
    }
}
