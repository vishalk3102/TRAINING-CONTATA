 var taxFormList = await _db.TaxDeclarations
                            .Join(_db.Users, 
                                    td => td.EmpId,
                                    u => u.Id, 
                                    (td, u) => new 
                                    {
                                        Id = td.TaxId,
                                        FinancialYear = td.FinancialYear,
                                        DeclarationStatus = td.Status,
                                        DeclarationDate = td.DateOfDeclaration,
                                        EmployeeName = u.Name 
                                    })
                            .ToListAsync();