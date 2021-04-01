﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTeamFour_Backend.Interfaces;
using ProjectTeamFour_Backend.Models;
using ProjectTeamFour_Backend.ViewModels;

namespace ProjectTeamFour_Backend.Services
{
    public class BackendMemberService : IBackendMemberService
    {
        private readonly IRepository _repository;

        public BackendMemberService(IRepository repository)
        {
            _repository = repository;
        }
        public BackendMemberViewModel.BackendListResult GetAll()
        {
            BackendMemberViewModel.BackendListResult result = new BackendMemberViewModel.BackendListResult();

            result.BackendMemberList = _repository.GetAll<Backendmember>().Select(
                b => new BackendMemberViewModel.BackendSingleResult()
                {
                    MemberId=b.MemberId,
                    MemberName=b.MemberName,
                    MemberAccount=b.MemberAccount,
                    MemberAddress=b.MemberAddress,
                    MemberBirth= b.MemberBirth.ToString("d"),
                    MemberConEmail=b.MemberConEmail,
                    MemberRegEmail=b.MemberRegEmail,
                    MemberPhone=b.MemberPhone,
                    BackendIdentity=b.BackendIdentity,
                    Gender=b.Gender,
                    MemberMessage=b.MemberMessage,
                }).ToList();
            return result;
        }
    }
}