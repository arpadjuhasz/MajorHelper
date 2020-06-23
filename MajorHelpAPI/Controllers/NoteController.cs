using MajorHelp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorHelpAPI.Controllers
{
    [Route("notes")]
    public class NoteController : Controller
    {
        [HttpGet()]
        public IActionResult GetMajor([FromQuery]string note, [FromQuery]string modifier)
        {
            NoteEnum noteEnum = (NoteEnum)Enum.Parse(typeof(NoteEnum), note.ToUpper());
            NoteModifierEnum noteModifierEnum = (NoteModifierEnum)Enum.Parse(typeof(NoteModifierEnum), modifier.ToUpper());
            //var list = MajorHelp.MajorGenerator.GetMajor(noteEnum, noteModifierEnum);
            return Ok();
        }
    }
}
