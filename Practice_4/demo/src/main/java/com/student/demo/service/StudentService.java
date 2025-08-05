package com.student.demo.service;

import java.util.regex.Pattern;

import org.springframework.stereotype.Service;

@Service
public class StudentService {
    
    public Boolean isValidEmail(String email) {
        // Regex pattern for a reasonably strict email validation
        String emailRegex = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
        Pattern pattern = Pattern.compile(emailRegex);
        Boolean isValid = pattern.matcher(email).matches();
        if(isValid){
            return true;
        } else {
            throw new IllegalArgumentException("Invalid email format");
        }
    }
}
