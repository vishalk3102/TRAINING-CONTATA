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
                var taxDeclarationsList = await _taxDeclarationService.getAllTaxDeclarations();
                if (taxDeclarationsList == null)
                {
                    return NotFound();
                }
                var taxDeclarations = taxDeclarationsList.Select(tuple => new
                {
                    TaxDeclaration = tuple.Item1,
                    Employee = tuple.Item2
                });

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
                var taxDeclarationsList = await _taxDeclarationService.getTaxDeclaration(taxId);
                if (taxDeclarationsList == null)
                {
                    return NotFound();
                }

                var taxDeclaration = taxDeclarationsList.Select(tuple => new
                {
                    TaxDeclaration = tuple.Item1,
                    Employee = tuple.Item2
                });

                return Ok(taxDeclaration);
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
                var taxDeclarationsList = await _taxDeclarationService.getChangeRequestTaxDeclaration();
                if (taxDeclarationsList == null)
                {
                    return NotFound();
                }
                var taxDeclarations = taxDeclarationsList.Select(tuple => new
                {
                    reason=tuple.Item1,
                    TaxDeclaration = tuple.Item2,
                    Employee = tuple.Item3
                });
                return Ok(taxDeclarations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
           
        }

        //SUBMIT TAX DECLARATION 
        [HttpPost("employee/taxform/submit")]
        public async Task<IActionResult> SubmitTaxDeclaration(TaxDeclaration tax)
        {
            try
            {
                var existingTax = _taxDeclarationService.getTaxDeclarationByFinancialYear(tax.financialYear);
                if(existingTax == null)
                {
                  await _taxDeclarationService.submitTaxDeclaration(tax);
                  return CreatedAtAction(nameof(GetTaxDeclaration), new { taxId = tax.taxId }, tax);
                }
                else
                {
                    await _taxDeclarationService.updateTaxDeclaration(tax);
                    return Ok("Form Submitted Successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        //SAVE TAX DECLARATION 
        [HttpPost("employee/taxform/save")]
        public async Task<IActionResult> SaveTaxDeclaration(TaxDeclaration tax)
        {
            try
            {
                var existingTax = _taxDeclarationService.getTaxDeclarationByFinancialYear(tax.financialYear);
                if (existingTax == null)
                {
                    await _taxDeclarationService.saveTaxDeclaration(tax);
                    return CreatedAtAction(nameof(GetTaxDeclaration), new { taxId = tax.taxId }, tax);
                }
                else
                {
                    await _taxDeclarationService.updateTaxDeclaration(tax);
                    return Ok("Form saved Successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }


        //UPDATE TAX DECLARATION DETAILS
        [HttpPut("admin/tax/update/{taxId}")]
        public async Task<IActionResult> UpdateTaxDeclaration(TaxDeclaration taxDeclaration, int taxId)
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


        //UNFREEZE FORM 
        [HttpGet("admin/tax/unfreeze/{taxid}")]
        public async Task<IActionResult> UnfreezeTaxForm(int taxId)
        {
            try
            {
                var taxFormList = await _taxDeclarationService.getTaxDeclaration(taxId);
                if (taxFormList == null || taxFormList.Any())
                {
                    return NotFound();
                }

                var taxForm = taxFormList.First().Item1;
                await _taxDeclarationService.unfreezeTaxForm(taxForm);
                await _taxDeclarationService.deleteChangeRequest(taxId);
                return Ok("Tax Form Unfreezed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Unexpected error occurred");
            }
        }

        //ACCEPT FORM 
        [HttpGet("admin/tax/accept/{taxid}")]
        public async Task<IActionResult> AcceptTaxForm(int taxId)
        {
            try
            {
                var taxFormList = await _taxDeclarationService.getTaxDeclaration(taxId);
            

                var taxForm = taxFormList.First().Item1;
                await _taxDeclarationService.acceptTaxForm(taxForm);
                return Ok("Tax Form Accepted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Unexpected error occurred");
            }
        }

        //REJECT FORM 
        [HttpGet("admin/tax/reject/{taxid}")]
        public async Task<IActionResult> RejectTaxForm(int taxId)
        {
            try
            {
                var taxFormList = await _taxDeclarationService.getTaxDeclaration(taxId);


                var taxForm = taxFormList.First().Item1;
                await _taxDeclarationService.rejectTaxForm(taxForm);
                return Ok("Tax Form Rejected successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An Unexpected error occurred");
            }
        }
    }
}