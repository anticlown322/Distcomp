﻿using Service.DTO.Request.Editor;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("/api/v1.0/editors")]
public class EditorController : ControllerBase
{
    private readonly IEditorService _editorService;

    public EditorController(IEditorService service)
    {
        _editorService = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEditors()
    {
        var editors = await _editorService.GetEditors(new EditorRequestToGetAll());
        return Ok(editors);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetEditorById(long id)
    {
        var editor = await _editorService.GetEditorById(new EditorRequestToGetById{ Id = id });
        return Ok(editor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEditor(EditorRequestToCreate editorRequestToCreate)
    {
        var editor = await _editorService.CreateEditor(editorRequestToCreate);
        return CreatedAtAction(nameof(GetEditorById), new { id = editor.Id }, editor);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEditor(EditorRequestToFullUpdate editorModel)
    {
        var editor = await _editorService.UpdateEditor(editorModel);
        return Ok(editor);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteEditor(long id)
    {
        await _editorService.DeleteEditor(new EditorRequestToDeleteById() { Id = id });
        return NoContent();
    }
}