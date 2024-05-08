package com.assignment.problemsolving;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;


@Controller
public class HomeController {
    
	private final FileService file;
	
	@Autowired
	public HomeController(FileService file)
	{
		this.file=file;
	}
	
	@GetMapping("/")
	public String readFile(Model model)
	{
		try
		{
			String fileContent=file.readFileContent("classpath:data");
			System.out.print(fileContent);
			model.addAttribute("content",fileContent);
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
		return "display.jsp";
	}
}
