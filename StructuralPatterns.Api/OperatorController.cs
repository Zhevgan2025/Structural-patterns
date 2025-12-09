using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StructuralPatterns.Api
{
    [ApiController]
    [Route("[controller]")]
    public class OperatorController : ControllerBase
    {
        private static readonly List<SomeEntity> _storage = new()
        {
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 1", Description = "Description 1", Status = 0 },
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 2", Description = "Description 2", Status = 1 },
            new SomeEntity { Id = Guid.NewGuid(), Name = "Entity 3", Description = "Description 3", Status = 2 },
        };

        [HttpGet("GetMany")]
        public IEnumerable<SomeEntity> GetMany()
            => _storage;

        [HttpPost("Create")]
        public ActionResult<SomeEntity> Create(SomeEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _storage.Add(entity);
            return entity;
        }


        // GET /Operator/GetOne/{id}
        [HttpGet("GetOne/{id}")]
        public ActionResult<SomeEntity> GetOne(Guid id)
        {
            var entity = _storage.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                return NotFound();

            return entity;
        }

        
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _storage.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                return NotFound();

            _storage.Remove(entity);
            return Ok();
        }
        // PUT /Operator/Update
        [HttpPut("Update")]
        public ActionResult<SomeEntity> Update(SomeEntity entity)
        {
            var existing = _storage.FirstOrDefault(e => e.Id == entity.Id);
            if (existing == null)
                return NotFound();

            existing.Name = entity.Name;
            existing.Description = entity.Description;
            existing.Status = entity.Status;

            return existing;
        }


        // POST /Operator/SetStatus
        [HttpPost("SetStatus")]
        public IActionResult SetStatus(Guid id, int status)
        {
            var entity = _storage.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                return NotFound();

            entity.Status = status;
            return Ok();
        }

        // POST /Operator/Activate
        [HttpPost("Activate")]
        public IActionResult Activate(Guid id)
            => SetStatus(id, 1);

        // POST /Operator/Deactivate
        [HttpPost("Deactivate")]
        public IActionResult Deactivate(Guid id)
            => SetStatus(id, 0);

        
        [HttpGet("GetByFilter")]
        public IEnumerable<SomeEntity> GetByFilter(int? status, string? namePart)
        {
            var query = _storage.AsEnumerable();

            if (status.HasValue)
                query = query.Where(e => e.Status == status.Value);

            if (!string.IsNullOrWhiteSpace(namePart))
                query = query.Where(e => e.Name.Contains(namePart, StringComparison.OrdinalIgnoreCase));

            return query;
        }


    }
}
