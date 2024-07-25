package com.cricinformer.cricinformerbackend.services;

import com.cricinformer.cricinformerbackend.entities.Match;

import java.util.List;
import java.util.Map;

public interface MatchService {

//GET ALL MATCHES
    List<Match> getAllMatches();


//GET LIVE MATCHES
    List<Match> getLiveMatches();


//GET CWC 2024 POINT TABLE
    List<List<String>> getPointTable();
}
