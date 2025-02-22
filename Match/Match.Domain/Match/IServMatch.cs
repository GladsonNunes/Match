﻿using Match.Domain.Match.DTO;
using Match.Domain.Matches.DTO;

namespace Match.Domain.Match
{
    public interface IServMatch
    {
        DadosMatchDeveloperToProjectDTO MatchDeveloperToProject(int projectId);
        DadosMatchProjectToDeveloperDTO MatchProjectToDeveloper(int developerId);
        void CreateMatch(CreateMatchDTO dto);
        void UpdateStatus(int matchId);
        Match GetMatchById(int matchId);
    }
}
