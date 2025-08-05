package com.student.demo;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import com.student.demo.service.StudentService;

@SpringBootTest
class DemoApplicationTests {

	
	@Test
	void testValidEmail(){
		StudentService studentService = new StudentService();
		assertEquals(true, studentService.isValidEmail("sakib@email.com"));
	}

	@Test
	void testInvalidEmail(){
		StudentService studentService = new StudentService();
		assertThrows(IllegalArgumentException.class, () -> {
			studentService.isValidEmail("invalid-email format");
		});
	}

}
