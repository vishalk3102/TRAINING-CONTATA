@model dynamic
@using TaxManagementNew.Models

<section class= 'w-full h-full' >
    < div class= 'max-w-[1200px] mx-auto my-20' >
    < div className = 'text-[1.8rem] font-medium text-center p-2 my-2' >
            < h1 > Tax Declaration </ h1 >
        </ div >
   < form method = "post" id = "taxForm" asp - action = "ViewTaxForm" >
            < div class= "border-2 my-2 flex items-center justify-between border-solid border-black py-2" >
                < div class= "text-[16px] p-4 font-medium" >
                    Employee ID: < span class= "p-2" > @Model.ApplicationUser.EmpId </ span >
                </ div >
                < div class= "text-[16px] p-4 font-medium" >
                    Employee Name: < span class= "p-2" > @Model.ApplicationUser.Name </ span >
                </ div >
                < div class= "text-[16px] p-4 font-medium" >
                    Financial Year: < span class= "p-2" > @Model.TaxDeclaration.FinancialYear </ span >
                </ div >
            </ div >
            < div class= "border-2 border-solid border-black" >
                < div class= "ml-2 flex items-center py-2" >
                    < div class= "w-[70%] py-1" >
                        < label class= "text-[14px]" >
                            1.) Any other income (interest from property, rental income, etc.)
                        </label>
                    </div>
                    <div class= "w-[25%]" >
                        < input type = "text" value = "@Model.TaxDeclaration.AnyOtherIncome"
                               class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                    </ div >
                </ div >
                < div class= '' >
                    < h4 class= 'text-[14px] py-2 ml-2' >
                        2.) Investment under Section 80C
                    </h4>
                    <div class= 'py-2 ml-3' >
                        < div class= "ml-2 flex items-center py-2" >
                            < div class= "w-[70%] py-1" >
                                < label class= "text-[14px]" >
                                    a.) Sukanya Samriddhi Account
                                </label>
                            </div>
                            <div class= "w-[25%]" >
                                < input type = "text" value = "@Model.TaxDeclaration.SukanyaSamriddhiAccount"
                                       class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                            </ div >
                        </ div >
                        < div class= "ml-2 flex items-center py-2" >
                            < div class= "w-[70%] py-1" >
                                < label class= "text-[14px]" > b.) PPF / NSC </ label >
                            </ div >
                            < div class= "w-[25%]" >
                                < input type = "text" value = "@Model.TaxDeclaration.PPF"
                                       class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                            </ div >
                        </ div >
                        < div class= "ml-2 flex items-center py-2" >
                            < div class= "w-[70%] py-1" >
                                < label class= "text-[14px]" >
                                    c.) Life Insurance Premium
                                </label>
                            </div>
                            <div class= "w-[25%]" >
                                < input type = "text" value = "@Model.TaxDeclaration.LifeInsurancePremium"
                                       class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                            </ div >
                        </ div >
                        < div class= "ml-2 flex items-center py-2" >
                            < div class= "w-[70%] py-1" >
                                < label class= "text-[14px]" > d.) Tuition fee for child</label>
                            </div>
                            <div class= "w-[25%]" >
                                < input type = "text" value = "@Model.TaxDeclaration.TuitionFee"
                                       class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                            </ div >
                        </ div >
                        < div class= "ml-2 flex items-center py-2" >
                            < div class= "w-[70%] py-1" >
                                < label class= "text-[14px]" >
                                    e.) Bank Fixed Deposits/NSC (in Five Years)
                                </label>
                            </div>
                            <div class= "w-[25%]" >
                                < input type = "text" value = "@Model.TaxDeclaration.BankFixedDeposit"
                                       class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                            </ div >
                        </ div >
                        < div class= "ml-2 flex items-center py-2" >
                            < div class= "w-[70%] py-1" >
                                < label class= "text-[14px]" >
                                    f.) Principal amount of housing loan paid during the year
                                </label>
                            </div>
                            <div class= "w-[25%]" >
                                < input type = "text" value = "@Model.TaxDeclaration.PrincipalHousingLoan"
                                       class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                            </ div >
                        </ div >
                        < div class= "ml-2 flex items-center py-2" >
                            < div class= "w-[70%] py-1" >
                                < label class= "text-[14px]" >
                                    g.) National Pension Scheme 80CCD (1B) (Limit 50k)
                                </label>
                            </div>
                            <div class= "w-[25%]" >
                                < input type = "text" value = "@Model.TaxDeclaration.NPS"
                                       class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                            </ div >
                        </ div >
                    </ div >
                </ div >
                < div class= "ml-2 flex items-center py-2" >
                    < div class= "w-[70%] py-1" >
                        < label class= "text-[14px]" >
                            3.) Higher Education Loan interest via EDE
                        </label>
                    </div>
                    <div class= "w-[25%]" >
                        < input type = "text" value = "@Model.TaxDeclaration.HigherEducationLoanInterest"
                               class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                    </ div >
                </ div >
                < div class= "ml-2 flex items-center py-2" >
                    < div class= "w-[70%] py-1" >
                        < label class= "text-[14px]" >
                            4.) Interest paid on Housing Loan via 24
                        </label>
                    </div>
                    <div class= "w-[25%]" >
                        < input type = "text" value = "@Model.TaxDeclaration.InterestHousingLoan"
                               class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                    </ div >
                </ div >
                < div class= "ml-2 flex items-center py-2" >
                    < div class= "w-[70%] py-1" >
                        < label class= "text-[14px]" >
                            5.) House Rent paid (every month/For above amt Rs 8333/-PM) (part of amount liable to provide)
                        </label>
                    </div>
                    <div class= "w-[25%]" >
                        < input type = "text" value = "@Model.TaxDeclaration.HouseRent"
                               class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                    </ div >
                </ div >
                < div class= "ml-2 flex items-center py-2" >
                    < div class= "w-[70%] py-1" >
                        < label class= "text-[14px]" >
                            6.) Tax Deducted at Source by the previous employer at TCS
                        </label>
                    </div>
                    <div class= "w-[25%]" >
                        < input type = "text" value = "@Model.TaxDeclaration.TDS"
                               class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                    </ div >
                </ div >
                < div class= "ml-2 flex items-center py-2" >
                    < div class= "w-[70%] py-1" >
                        < label class= "text-[14px]" >
                            7.) Health insurance policy - Premium (RS 25,000)
                        </label>
                    </div>
                    <div class= "w-[25%]" >
                        < input type = "text" value = "@Model.TaxDeclaration.MediClaim"
                               class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                    </ div >
                </ div >
                < div class= "ml-2 flex items-center py-2" >
                    < div class= "w-[70%] py-1" >
                        < label class= "text-[14px]" >
                            8.) Preventive Health check-up for Self & Family (80D) (Limit 5k)
                        </label>
                    </div>
                    <div class= "w-[25%]" >
                        < input type = "text" value = "@Model.TaxDeclaration.PreventiveHealthCheckUp"
                               class= "w-[100%] border-2 text-[14px] border-solid border-black px-2 py-1 outline-none" disabled >
                    </ div >
                </ div >
            </ div >

            < div class= "mt-4" >
                < div class= "text-[1.4rem] mt-2 py-2 text-left font-medium" >
                    < h1 > Reimbursement Component </ h1 >
                </ div >
                < div class= "border-2 flex flex-col border-solid border-black py-4" >
                    < div class= "flex py-1" >
                        < div class= "w-[70%]" >
                            < label class= "leading-7 p-2 text-sm" >
                                LTA(Do you want LTA as a Reimbursement)
                            </ label >
                        </ div >
                        < div class= "flex items-center justify-center" >
                            < input type = "checkbox" class= "h-[20px] w-[20px]"
                                   checked= "@Model.TaxDeclaration.LTA" disabled >
                        </ div >
                    </ div >
                </ div >
            </ div >

            < div class= "my-2 flex justify-between" >
                < div class= "text-[16px] p-4 font-medium" >
                    Staff No: < span class= "p-2" > @Model.ApplicationUser.EmpId </ span >
                </ div >
                < div class= "text-[16px] p-4 font-medium" >
                    Name of the Staff: < span class= "p-2" > @Model.ApplicationUser.Name </ span >
                </ div >
                < div class= "text-[16px] p-4 font-medium" >
                    PAN No: < span class= "p-2" > @Model.ApplicationUser.PanNo </ span >
                </ div >
                < div class= "text-[16px] p-4 font-medium" >
                    Address: < span class= "p-2" > @Model.ApplicationUser.Address </ span >
                </ div >
            </ div >
        </ form >
    </ div >
</ section >