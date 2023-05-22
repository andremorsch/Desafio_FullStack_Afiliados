import Form from "react-bootstrap/Form";

export default function UploadForm() {
  return (
    <>
      <Form.Group controlId="formFile" className="mb-3">
        <Form.Label>Escolha o arquivo .txt para atualizar</Form.Label>
        <Form.Control type="file" />
      </Form.Group>
    </>
  );
}
