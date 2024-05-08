using server.Services;
using Microsoft.AspNetCore.Mvc;
using server.Model;
using server.Services;
using System.Xml.Linq;

namespace server.Controllers
{

    [ApiController]
    [Route("/api/v1/")]
    public class TaxDeclarationController : Controller
    {
        private readonly TaxDeclarationService _taxDeclarationService;

        public TaxDeclarationController(TaxDeclarationService taxDeclarationService)
        {
            _taxDeclarationService = taxDeclarationService;
        }



        //GET ALL TAX SUBMISSIONS FROM DATABASE
        [HttpGet("admin/submissions")]
        public async Task<IActionResult> GetAllTaxDeclaration()
        {
            try
            {
                var taxDeclarations = await _taxDeclarationService.getAllTaxDeclarations();
                return Ok(taxDeclarations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }


        //GET  TAX SUBMISSIONS BY TAXID FROM DATABASE
        [HttpGet("tax-submission/{taxId}")]
        public async Task<IActionResult> GetTaxDeclaration(int taxId)
        {
            try
            {
                var taxDeclarations = await _taxDeclarationService.getTaxDeclaration(taxId);
                if (taxDeclarations == null)
                {
                    return NotFound();
                }
                return Ok(taxDeclarations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
           
        }

        //GET ALL SUBMISSION OF SPECIFIC USER 
        [HttpGet("submissions/{empId}")]
        public async Task<IActionResult> GetMyTaxDeclaration(int empId)
        {
            try
            {
                var taxDeclarations = await _taxDeclarationService.getMyTaxDeclaration(empId);
                if (taxDeclarations == null)
                {
                    return NotFound();
                }
                return Ok(taxDeclarations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }



        //GET ALL TAX SUBMISSIONS WITH CHANGE REQUEST  
        [HttpGet("admin/taxes")]
        public async Task<IActionResult> GetChangeRequestTaxDeclaration()
        {

            try
            {
                var taxDeclarations = await _taxDeclarationService.getChangeRequestTaxDeclaration();
                if (taxDeclarations == null)
                {
                    return NotFound();
                }
                return Ok(taxDeclarations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
           
        }




        //SUBMIT TAX DECLARATION 
        [HttpPost("employee/taxform/submit")]
        public async Task<IActionResult> CreateTaxDeclaration(TaxDeclaration tax)
        {
            try
            {
                await _taxDeclarationService.createTaxDeclaration(tax);
                return CreatedAtAction(nameof(GetTaxDeclaration), new { taxId = tax.taxId }, tax);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
           
        }



        //REQUEST TO CHANGE DETAILS IN TAX FORM
        [HttpPost("change-request")]
        public async Task<IActionResult> ChangeRequest(ChangeRequest changeRequest)
        {
            try
            {
                var result = await _taxDeclarationService.changeRequest(changeRequest);
                if (result)
                {
                    return Ok("Request For Change submitted succesfully");
                }
                else
                {
                    return BadRequest("Failed to submit the request for change.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
            
        }



        //UPDATE TAX DECLARATION DETAILS
        [HttpPut("admin/tax/update/{taxId}")]
        public async Task<IActionResult> UpdateTaxDeclaration(TaxDeclaration taxDeclaration,int taxId)
        {
            try
            {
                if (taxId != taxDeclaration.taxId)
                {
                    return BadRequest();
                }

                await _taxDeclarationService.updateTaxDeclaration(taxDeclaration);
                return Ok("Form Submitted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }



        //UNFREEZE FORM 
        [HttpGet("admin/tax/unfreeze/{taxid}")]
        public async Task<IActionResult> UnfreezeTaxForm(int taxId)
        {
            try
            {
                var taxForm = await _taxDeclarationService.getTaxDeclaration(taxId);
                if (taxForm == null)
                {
                    return NotFound();
                }

                await _taxDeclarationService.unfreezeTaxForm(taxForm);
                await _taxDeclarationService.deleteChangeRequest(taxId);
                return Ok("Tax Form Unfreezed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Unexpected error occurred");
            }
        }
    }
}