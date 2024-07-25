package com.cricinformer.cricinformerbackend.repositories;

import com.cricinformer.cricinformerbackend.entities.Match;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface MatchRepo extends JpaRepository<Match,Integer> {


//    TO FETCH MATCH BASED ON TEAMHEADING
    Optional<Match> findByTeamHeading(String teamHeading);
}
