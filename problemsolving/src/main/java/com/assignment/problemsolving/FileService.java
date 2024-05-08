package com.assignment.problemsolving;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;

import org.springframework.stereotype.Service;
import org.springframework.util.ResourceUtils;

@Service
public class FileService{

	
	public String readFileContent(String filePath) throws IOException
	{
		File file=ResourceUtils.getFile(filePath);
		String content = new String(Files.readAllBytes(file.toPath()));
		return content;
	}
	
}
