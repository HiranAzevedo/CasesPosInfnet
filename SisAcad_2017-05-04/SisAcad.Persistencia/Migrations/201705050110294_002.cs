namespace SisAcad.Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Turma", new[] { "Curso_CursoID" });
            DropIndex("dbo.ProfessorCurso", new[] { "Curso_CursoID" });
            AddColumn("dbo.Curso", "Descricao", c => c.String(maxLength: 100, unicode: false));
            CreateIndex("dbo.Turma", "Curso_CursoId");
            CreateIndex("dbo.ProfessorCurso", "Curso_CursoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProfessorCurso", new[] { "Curso_CursoId" });
            DropIndex("dbo.Turma", new[] { "Curso_CursoId" });
            DropColumn("dbo.Curso", "Descricao");
            CreateIndex("dbo.ProfessorCurso", "Curso_CursoID");
            CreateIndex("dbo.Turma", "Curso_CursoID");
        }
    }
}
