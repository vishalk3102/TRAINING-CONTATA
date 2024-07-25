package com.cricinformer.cricinformerbackend.controllers;


import com.cricinformer.cricinformerbackend.entities.Match;
import com.cricinformer.cricinformerbackend.services.MatchService;
import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/match")
public class MatchController {

    private MatchService matchService;

    public MatchController(MatchService matchService) {
        this.matchService = matchService;
    }

    //GET LIVE MATCHES
    @GetMapping("/live")
    public ResponseEntity<List<Match>> getLiveMatches(){
        return new ResponseEntity<>(this.matchService.getLiveMatches(), HttpStatus.OK);
    }

    //GET ALL MATCHES
    @GetMapping
    public ResponseEntity<List<Match>> getAllMatches()
    {
        return new ResponseEntity<>(this.matchService.getAllMatches(),HttpStatus.OK);
    }

    @GetMapping("/point-table")
    public ResponseEntity<List<List<String>>> getPointTable()
    {
        return new ResponseEntity<>(this.matchService.getPointTable(),HttpStatus.OK);
    }
}
