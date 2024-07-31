package com.example.securityCrud.entity;


import lombok.*;


@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
@Builder
@ToString
public class JwtRequest {
   private String email;
   private String password;
}
