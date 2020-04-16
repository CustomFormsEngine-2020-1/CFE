using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CFE.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Element",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(maxLength: 50, nullable: false),
            //         Description = table.Column<string>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Element", x => x.Id);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "User",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Login = table.Column<string>(maxLength: 50, nullable: false),
            //         Password = table.Column<string>(maxLength: 50, nullable: false),
            //         Email = table.Column<string>(maxLength: 50, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_User", x => x.Id);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "Attribute",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(nullable: false),
            //         DisplayName = table.Column<string>(nullable: false),
            //         ElementId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Attribute", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Attribute_Element_ElementId",
            //             column: x => x.ElementId,
            //             principalTable: "Element",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "Form",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(maxLength: 50, nullable: false),
            //         Description = table.Column<string>(nullable: true),
            //         DTCreate = table.Column<DateTime>(nullable: false),
            //         DTStart = table.Column<DateTime>(nullable: false),
            //         DTFinish = table.Column<DateTime>(nullable: false),
            //         IsPrivate = table.Column<bool>(nullable: false),
            //         IsAnonymity = table.Column<bool>(nullable: false),
            //         IsEditingAfterSaving = table.Column<bool>(nullable: false),
            //         UserId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Form", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Form_User_UserId",
            //             column: x => x.UserId,
            //             principalTable: "User",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "AttributeResult",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Value = table.Column<string>(nullable: false),
            //         AttributeId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AttributeResult", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AttributeResult_Attribute_AttributeId",
            //             column: x => x.AttributeId,
            //             principalTable: "Attribute",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "FormResult",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         DTResult = table.Column<DateTime>(nullable: false),
            //         FormId = table.Column<int>(nullable: false),
            //         UserId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_FormResult", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_FormResult_Form_FormId",
            //             column: x => x.FormId,
            //             principalTable: "Form",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Restrict);
            //         table.ForeignKey(
            //             name: "FK_FormResult_User_UserId",
            //             column: x => x.UserId,
            //             principalTable: "User",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Restrict);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "Question",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(maxLength: 50, nullable: false),
            //         FormId = table.Column<int>(nullable: false),
            //         ElementId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Question", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Question_Element_ElementId",
            //             column: x => x.ElementId,
            //             principalTable: "Element",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Question_Form_FormId",
            //             column: x => x.FormId,
            //             principalTable: "Form",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "Answer",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(maxLength: 50, nullable: false),
            //         QuestionId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Answer", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Answer_Question_QuestionId",
            //             column: x => x.QuestionId,
            //             principalTable: "Question",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "QuestionResult",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         QuestionId = table.Column<int>(nullable: false),
            //         FormResultId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_QuestionResult", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_QuestionResult_FormResult_FormResultId",
            //             column: x => x.FormResultId,
            //             principalTable: "FormResult",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_QuestionResult_Question_QuestionId",
            //             column: x => x.QuestionId,
            //             principalTable: "Question",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            // 
            // migrationBuilder.CreateTable(
            //     name: "AnswerResult",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Value = table.Column<string>(nullable: false),
            //         QuestionResultId = table.Column<int>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AnswerResult", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AnswerResult_QuestionResult_QuestionResultId",
            //             column: x => x.QuestionResultId,
            //             principalTable: "QuestionResult",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_Answer_QuestionId",
            //     table: "Answer",
            //     column: "QuestionId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_AnswerResult_QuestionResultId",
            //     table: "AnswerResult",
            //     column: "QuestionResultId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_Attribute_ElementId",
            //     table: "Attribute",
            //     column: "ElementId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_AttributeResult_AttributeId",
            //     table: "AttributeResult",
            //     column: "AttributeId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_Form_UserId",
            //     table: "Form",
            //     column: "UserId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_FormResult_FormId",
            //     table: "FormResult",
            //     column: "FormId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_FormResult_UserId",
            //     table: "FormResult",
            //     column: "UserId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_Question_ElementId",
            //     table: "Question",
            //     column: "ElementId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_Question_FormId",
            //     table: "Question",
            //     column: "FormId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_QuestionResult_FormResultId",
            //     table: "QuestionResult",
            //     column: "FormResultId");
            // 
            // migrationBuilder.CreateIndex(
            //     name: "IX_QuestionResult_QuestionId",
            //     table: "QuestionResult",
            //     column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "Answer");
            // 
            // migrationBuilder.DropTable(
            //     name: "AnswerResult");
            // 
            // migrationBuilder.DropTable(
            //     name: "AttributeResult");
            // 
            // migrationBuilder.DropTable(
            //     name: "QuestionResult");
            // 
            // migrationBuilder.DropTable(
            //     name: "Attribute");
            // 
            // migrationBuilder.DropTable(
            //     name: "FormResult");
            // 
            // migrationBuilder.DropTable(
            //     name: "Question");
            // 
            // migrationBuilder.DropTable(
            //     name: "Element");
            // 
            // migrationBuilder.DropTable(
            //     name: "Form");
            // 
            // migrationBuilder.DropTable(
            //     name: "User");
        }
    }
}
