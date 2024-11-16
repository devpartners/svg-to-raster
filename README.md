# svg-to-raster
Console app that converts an SVG to a raster format

## Usage

To use the console app, run the following command:

```bash
svg-to-raster <input-svg-file> [output-file] [output-format]
```

### Arguments

- `<input-svg-file>`: The path to the SVG file that needs to be converted.
- `[output-file]` (optional): The path where the output raster image should be saved. If not provided, the output file will be saved in the same directory as the input file with the same name but with a different extension (e.g., `.png`).
- `[output-format]` (optional): The desired output format (e.g., `png`, `jpeg`, `gif`). If not provided, the default format will be `png`.

### Examples

Convert an SVG file to PNG format (default):

```bash
svg-to-raster foo.svg
```

Convert an SVG file to JPEG format:

```bash
svg-to-raster foo.svg foo.jpeg jpeg
```

Convert an SVG file to GIF format and specify the output file path:

```bash
svg-to-raster foo.svg output/foo.gif gif
```
