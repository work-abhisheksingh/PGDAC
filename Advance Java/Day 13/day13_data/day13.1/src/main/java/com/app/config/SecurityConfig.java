package com.app.config;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.provisioning.InMemoryUserDetailsManager;
import org.springframework.security.web.SecurityFilterChain;

@EnableWebSecurity
@Configuration
@EnableGlobalMethodSecurity(prePostEnabled = true)
public class SecurityConfig {
	//dep : password encoder
	@Autowired
	private PasswordEncoder enc;
	
	@Bean
	public UserDetailsService users() {
		User customer=new User("Rama",enc.encode("12345"), List.of(new SimpleGrantedAuthority("ROLE_ADMIN")));
		User admin=new User("Kiran",enc.encode("2345"), List.of(new SimpleGrantedAuthority("ROLE_CUSTOMER")));
		
		return new InMemoryUserDetailsManager(customer,admin);
	}
	@Bean
	public SecurityFilterChain authorizeRequests(HttpSecurity http) throws Exception
	{
		http.authorizeRequests()
	//	.antMatchers(HttpMethod.GET,"/**").permitAll()
		.antMatchers("/products/view").permitAll()
		.antMatchers("/products/purchase").hasRole("CUSTOMER")
		.antMatchers("/products/add").hasRole("ADMIN")
		.anyRequest().authenticated()
		.and()
		.httpBasic();
		return http.build();
	}
}
