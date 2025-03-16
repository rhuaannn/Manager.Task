using AutoMapper;
using Manager.Task.Application;
using Manager.Task.Application.Interfaces;
using Manager.Task.Domain.DTO;
using Manager.Task.Domain.Task;
using Manager.Task.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITask taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var tasks = await _taskService.GetTaskAllAsync();
            var taskDtos = _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
            return Ok(taskDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskDto taskDto)
        {
            var task = _mapper.Map<ManagerTask>(taskDto);
            var createTask = await _taskService.CreateTaskAsync(task);
            return Ok(createTask);
        }
    }
}
