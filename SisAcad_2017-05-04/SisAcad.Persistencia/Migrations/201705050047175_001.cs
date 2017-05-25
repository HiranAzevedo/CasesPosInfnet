namespace SisAcad.Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Matricula = c.String(maxLength: 100, unicode: false),
                        Turma_TurmaId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.Turma", t => t.Turma_TurmaId)
                .ForeignKey("dbo.Usuario", t => t.Usuario_UsuarioId)
                .Index(t => t.Turma_TurmaId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.Turma",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Professor_ProfessorId = c.Int(),
                        Curso_CursoID = c.Int(),
                    })
                .PrimaryKey(t => t.TurmaId)
                .ForeignKey("dbo.Professor", t => t.Professor_ProfessorId)
                .ForeignKey("dbo.Curso", t => t.Curso_CursoID)
                .Index(t => t.Professor_ProfessorId)
                .Index(t => t.Curso_CursoID);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CursoID);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Matricula = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 100, unicode: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ProfessorCurso",
                c => new
                    {
                        Professor_ProfessorId = c.Int(nullable: false),
                        Curso_CursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_ProfessorId, t.Curso_CursoID })
                .ForeignKey("dbo.Professor", t => t.Professor_ProfessorId)
                .ForeignKey("dbo.Curso", t => t.Curso_CursoID)
                .Index(t => t.Professor_ProfessorId)
                .Index(t => t.Curso_CursoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluno", "Usuario_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Turma", "Curso_CursoID", "dbo.Curso");
            DropForeignKey("dbo.Turma", "Professor_ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.ProfessorCurso", "Curso_CursoID", "dbo.Curso");
            DropForeignKey("dbo.ProfessorCurso", "Professor_ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Aluno", "Turma_TurmaId", "dbo.Turma");
            DropIndex("dbo.ProfessorCurso", new[] { "Curso_CursoID" });
            DropIndex("dbo.ProfessorCurso", new[] { "Professor_ProfessorId" });
            DropIndex("dbo.Turma", new[] { "Curso_CursoID" });
            DropIndex("dbo.Turma", new[] { "Professor_ProfessorId" });
            DropIndex("dbo.Aluno", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Aluno", new[] { "Turma_TurmaId" });
            DropTable("dbo.ProfessorCurso");
            DropTable("dbo.Usuario");
            DropTable("dbo.Professor");
            DropTable("dbo.Curso");
            DropTable("dbo.Turma");
            DropTable("dbo.Aluno");
        }
    }
}
